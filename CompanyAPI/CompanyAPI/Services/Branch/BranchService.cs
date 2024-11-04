using CompanyAPI.Data;
using CompanyAPI.Dto.BranchDTOS;
using CompanyAPI.Dto.CompanyDTOS;
using CompanyAPI.Repository.Branch;
using CompanyAPI.Services.Exceptions;
using CompanyAPI.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CompanyAPI.Services.Branch
{
    public class BranchService : IBranchService
    {
        private readonly IBranchRepository _branchRepository;

        public BranchService(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
        }

        public async Task<ResponseModel<List<BranchModel>>> CreateFilial(CreateBranchDto branchDto)
        {
            ResponseModel<List<BranchModel>> reply = new ResponseModel<List<BranchModel>>();

            try
            {
                bool branchExists = await _branchRepository.CheckBranchExistByHeadOfficeAsync(branchDto.HeadOffice);
                if (branchExists)
                {
                    throw new ConflictException("This HeadOffice already exists");
                }

                var Branch = new BranchModel()
                {
                    HeadOffice = branchDto.HeadOffice,
                };


                Branch.CompanyID = branchDto.CompanyLinkedID;


                await _branchRepository.AddBranchAsync(Branch);

                reply.Dados = await _branchRepository.GetBranchesInCompanyAsync(Branch.Id);
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
                bool branchExists = await _branchRepository.CheckBranchExistByIdAsync(branchDto.IdBranch);


                if (!branchExists)
                {
                    throw new NotFoundException("Branch not found");
                }


                var branch = await _branchRepository.GetBranchByIdAsync(branchDto.IdBranch);

                branch.CompanyID = branchDto.CompanyLinkedID;

                branch.HeadOffice = branchDto.HeadOffice;

                await _branchRepository.UpdateBranchAsync(branch);

                reply.Dados = await _branchRepository.GetBranchesInCompanyAsync(branchDto.CompanyLinkedID);
                reply.Mensagem = "Branch updated successfully";

                return reply;
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbUpdateException(e.Message);
            }
        }

        public async Task<ResponseModel<BranchModel>> InformationsAboutBranch(int branchId)
        {
            ResponseModel<BranchModel> reply = new ResponseModel<BranchModel>();

            try
            {
                var branch = await _branchRepository.GetAllDetailsAboutBranchAsync(branchId);

                if (branch == null)
                {
                    throw new NotFoundException("Branch not found");
                }

                reply.Dados = branch;
                reply.Mensagem = "Branch information retrieved successfully";
                return reply;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving Branch information: {ex.Message}");

            }

        }
            public async Task<ResponseModel<bool>> DeleteFilial(int branchId)
            {
                ResponseModel<bool> reply = new ResponseModel<bool>();

                try
                {
                    var branch = await _branchRepository.GetBranchByIdAsync(branchId);
                    if (branch == null)
                    {
                        throw new NotFoundException("Branch not found");
                    }

                    await _branchRepository.DeleteBranchAsync(branch);

                    reply.Dados = true;
                    reply.Mensagem = "Branch deleted successfully";
                    return reply;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error deleting Branch: {ex.Message}");
                }
            }



        public async Task<ResponseModel<List<BranchModel>>> ListAllBranchsInCompany(int companyId)
        {
            ResponseModel<List<BranchModel>> reply = new();
            try
            {
                bool companyExist = await _branchRepository.CheckCompanyExistByIdAsync(companyId);

                if (!companyExist)
                {
                    throw new NotFoundException("Company not found");
                }

                reply.Dados = await _branchRepository.GetBranchesInCompanyAsync(companyId);
                reply.Mensagem = "Branches successfully retrieved";
                return reply;
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException($"Error retrieving branches: {ex.Message}");
            }
        }

    }






}





