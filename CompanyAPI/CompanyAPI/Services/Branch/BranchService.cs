using CompanyAPI.Data;
using CompanyAPI.Dto.BranchDTOS;
using CompanyAPI.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CompanyAPI.Services.Branch
{
    public class BranchService
    {
        private readonly AppDbContext _context;

        public BranchService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<BranchModel>>> CreateFilial(CreateBranchDto branchDto)
        {
            ResponseModel<List<BranchModel>> reply = new ResponseModel<List<BranchModel>>();

            try
            {
                var branchExistsOrNot = await _context.Branchs.Include(x => x.HeadOffice).FirstOrDefaultAsync(x => x.HeadOffice == branchDto.HeadOffice);

                if (branchExistsOrNot == null)
                {
                    var Branch = new BranchModel()
                    {
                        HeadOffice = branchDto.HeadOffice

                    };

                    _context.Add(Branch);
                    await _context.SaveChangesAsync();

                 
                    reply.Mensagem = "successfully registered branch";

                    return reply;


                }

                else
                {
                    reply.Mensagem = "This Branchs Exists";

                    return reply;
                }



            }
            catch (Exception ex)
            {
                reply.Mensagem = ex.Message;

                return reply;
            }
        }
    }

}


