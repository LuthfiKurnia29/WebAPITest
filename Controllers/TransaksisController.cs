using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestDOT.Models;

namespace TestDOT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransaksisController : ControllerBase
    {
        private readonly EntityContext _context;

        public TransaksisController(EntityContext context)
        {
            _context = context;
        }

        // GET: api/Transaksis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transaksi>>> GetTransaksi()
        {
            return await _context.Transaksi.ToListAsync();
        }

        // GET: api/Transaksis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Transaksi>> GetTransaksi(Guid id)
        {
            var transaksi = await _context.Transaksi.FindAsync(id);

            if (transaksi == null)
            {
                return NotFound("Transaksi Tidak Ditemukan");
            }

            return transaksi;
        }

        // PUT: api/Transaksis/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransaksi(Guid id, Transaksi transaksi)
        {
            if (id != transaksi.Id)
            {
                return BadRequest();
            }
            var checkUser = _context.Users.Where(x => x.Id == transaksi.UserId).FirstOrDefault();
            if (checkUser == null)
            {
                return NotFound("User tidak ditemukan");
            }

            var checkProduct = _context.Products.Where(x => x.Id == transaksi.ProdukId).FirstOrDefault();
            if (checkProduct == null)
            {
                return NotFound("Produk tidak ditemukan");
            }
            _context.Entry(transaksi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransaksiExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(201);
        }

        // POST: api/Transaksis
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Transaksi>> PostTransaksi(Transaksi transaksi)
        {
            var checkUser = _context.Users.Where(x => x.Id == transaksi.UserId).FirstOrDefault();
            if (checkUser == null)
            {
                return NotFound("User tidak ditemukan");
            }

            var checkProduct = _context.Products.Where(x => x.Id == transaksi.ProdukId).FirstOrDefault();
            if(checkProduct == null)
            {
                return NotFound("Produk tidak ditemukan");
            }

            if(transaksi.JumlahBeli <= 0)
            {
                return NotFound("Jumlah Pembelian belum diinput");
            }

            _context.Transaksi.Add(transaksi);
            await _context.SaveChangesAsync();
            StatusCode(200);
            return CreatedAtAction("GetTransaksi", new { id = transaksi.Id }, transaksi);
        }

        // DELETE: api/Transaksis/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransaksi(Guid id)
        {
            var transaksi = await _context.Transaksi.FindAsync(id);
            if (transaksi == null)
            {
                return NotFound("Transaksi tidak ditemukan");
            }

            _context.Transaksi.Remove(transaksi);
            await _context.SaveChangesAsync();

            return StatusCode(201);
        }

        private bool TransaksiExists(Guid id)
        {
            return _context.Transaksi.Any(e => e.Id == id);
        }
    }
}
