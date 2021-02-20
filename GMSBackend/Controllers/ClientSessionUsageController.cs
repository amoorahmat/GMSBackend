﻿using GMSBackend.Entities;
using GMSBackend.Models;
using GMSBackend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace GMSBackend.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class ClientSessionUsageController : Controller
    {
        private DBRepository _dBRepository;
        private DBDapperRepository _dBDapperRepository;

        public ClientSessionUsageController(DBRepository dBRepository, DBDapperRepository dBDapperRepository)
        {
            _dBRepository = dBRepository;
            _dBDapperRepository = dBDapperRepository;
        }



        [HttpGet("get_client_sale_invoice_details")]
        public async Task<ActionResult> GetClientSaleInvoiceDetails(long customer_id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var query = $@" 
                                select h.id as invoice_id,d.id as sale_invoice_details_id,h.create_date as invoice_date,d.product_name,d.session_qty,d.session_used,(d.session_qty - d.session_used) > 0 as can_use
                                from public.sale_invoice_details d
                                join public.sale_invoice_headers h on d.invoice_id = h.id
                                where 1=1
                                and d.is_deleted='0'
                                and h.account_id = {customer_id} 
                                order by d.id desc ";

                var lst = await _dBDapperRepository.RunQueryAsync<ClientSessionUsageReportModel>(query);

                return Ok(new CoreResponse() { is_success = true, data = lst });

            }
            catch (Exception ex)
            {
                return Ok(new CoreResponse() { is_success = false, data = null, dev_message = ex.Message });
            }
        }


        [HttpPost("add_client_session_usage")]
        public async Task<ActionResult> AddClientSessionUsage(long customer_id, long sale_invoice_details_id, string description, bool is_use)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var detail = await _dBRepository.sale_invoice_details.AsNoTracking().FirstOrDefaultAsync(a => a.id == sale_invoice_details_id);
                if(detail == null)
                {
                    throw new Exception("there is no sale invoice detail with this id [sale_invoice_details_id]");
                }

                if(detail.session_qty - detail.session_used <= 0)
                {
                    throw new Exception($"this customer already has been used all sessions for this sale detail");
                }

                if(!is_use && detail.session_used == 0)
                {
                    throw new Exception("session used for this sale invoice detail row is already 0 so it can not lead to negative value");
                }

                var customer = await _dBRepository.accounts.AsNoTracking().FirstOrDefaultAsync(a => a.id == customer_id);
                if(customer == null)
                {
                    throw new Exception("there is no account with this id [customer_id]");
                }

                var obj = new ClientSessionUsageLog { account_id = customer_id, create_date = DateTime.Now, description = description, is_deleted = false, sale_invoice_details_id = sale_invoice_details_id, qty = (is_use ? 1 : -1) };
                await _dBRepository.client_session_usage_log.AddAsync(obj);
                await _dBRepository.SaveChangesAsync();

                await UpdateSaleInvoiceDetailSessionUsage(customer_id, sale_invoice_details_id);

                return Ok(new CoreResponse() { is_success = true, data = obj });

            }
            catch (Exception ex)
            {
                return Ok(new CoreResponse() { is_success = false, data = null, dev_message = ex.Message });
            }
        }



        private async Task UpdateSaleInvoiceDetailSessionUsage(long customer_id, long sale_invoice_details_id)
        {
            await _dBDapperRepository.RunQueryScalar(@$" update public.sale_invoice_details
                                                            set session_used = (select sum(qty) from public.client_session_usage_log where sale_invoice_details_id={sale_invoice_details_id} and account_id={customer_id} and is_deleted='0')
                                                            where id = {sale_invoice_details_id} ");
        }
    }
}