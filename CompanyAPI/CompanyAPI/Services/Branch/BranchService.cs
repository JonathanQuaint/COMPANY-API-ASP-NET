using CompanyAPI.Data;
using CompanyAPI.Dto.BranchDTOS;
using CompanyAPI.Dto.CompanyDTOS;
using CompanyAPI.Services.Exceptions;
using CompanyAPI.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CompanyAPI.Services.Branch
{
    public class BranchService : IBranchService
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
                bool branchExists = await _context.Branchs.AnyAsync(x => x.HeadOffice == branchDto.HeadOffice);
                bool CompanyExists = await _context.Company.AnyAsync(x => x.Id == branchDto.CompanyLinkedID);

                if (branchExists)
                {

                    throw new ConflictException("This HeadOffice already exists");

                }

                if (!CompanyExists) 
                {

                    throw new NotFoundException("Id of the company not found");

                }

               

                var Branch = new BranchModel()
                {
                 
                    HeadOffice = branchDto.HeadOffice,
                    
                 
                };


                //Company Linked of the filial
                var companyLinked = await _context.Company.FirstOrDefaultAsync(x => x.Id == branchDto.CompanyLinkedID);

                if (companyLinked == null)
                {

                    throw new ConflictException("Error companyLinked is null");

                }

                Branch.CompanyLinked = companyLinked;

                _context.Add(Branch);              
                await _context.SaveChangesAsync();
                companyLinked.Branch.Add(Branch);
                reply.Dados = await _context.Branchs.ToListAsync();
                reply.Mensagem = "successfully registered branch";

                return reply;


            }
            catch (DbUpdateException ex)
            {
                var innerException = ex.InnerException?.Message;
                throw new Exception($"Erro ao salvar dados: {innerException}");
            }



        }

        public async Task<ResponseModel<List<BranchModel>>> UpdateFilial(EditBranchDto branchDto)
        {

            ResponseModel<List<BranchModel>> reply = new ResponseModel<List<BranchModel>>();

            try
            {
                bool CompanyExists = await _context.Company.AnyAsync(x => x.Name == branchDto.CompanyLinkedName);
                bool branchExists = await _context.Branchs.AnyAsync(x => x.Id == branchDto.IdBranch && x.CompanyLinked.Name == branchDto.CompanyLinkedName);



            if (!branchExists)
            {
                throw new NotFoundException("Branch not found");

            }

            if (!CompanyExists)
                {

                    throw new NotFoundException("CompanyLinked not found");
            }


                var branch = await _context.Branchs.Include(x => x.CompanyLinked).FirstOrDefaultAsync(x => x.Id == branchDto.IdBranch && x.CompanyLinked.Name == branchDto.CompanyLinkedName);

                if (branch == null)
                {

                    throw new ConflictException("Error branch is null");

                }
                    branch.HeadOffice = branchDto.HeadOffice;

                    _context.Update(branch);
                    await _context.SaveChangesAsync();


                    reply.Dados = await _context.Branchs.ToListAsync();
                    reply.Mensagem = "Branch updated successfully";

                    return reply;
                
            }

            catch (DbUpdateConcurrencyException e)
            {
                throw new DbUpdateException(e.Message);


            }


        }

    }






}





