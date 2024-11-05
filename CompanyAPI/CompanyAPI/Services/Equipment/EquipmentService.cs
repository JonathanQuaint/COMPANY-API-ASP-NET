using CompanyAPI.Dto.EmployeeDTOS;
using CompanyAPI.Dto.EquipmentDTOS;
using CompanyAPI.Services.Exceptions;
using CompanyAPI.ViewModel;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.ComponentModel.Design;

namespace CompanyAPI.Services.Equipment
{
    public class EquipmentService : IEquipmentInterface
    {
        private readonly IEquipmentRepository _equipmentRepository;

        public EquipmentService(IEquipmentRepository EquipmentRepository)
        {
            _equipmentRepository = EquipmentRepository;
        }

        public async Task<ResponseModel<List<EquipmentModel>>> CreateEquipment(CreateEquipmentDto equipmentDto)
        {
            ResponseModel<List<EquipmentModel>> reply = new();

            try
            {

                var equipment = new EquipmentModel()
                {
                    AreaId = equipmentDto.AreaId,
                    Name = equipmentDto.NameEquipment,
                    Price = equipmentDto.Price,
                    AcquisitionDate = equipmentDto.AcquisitionDate,
                    Manufacturer = equipmentDto.Manufacturer,
                    Model = equipmentDto.Model,
                    Description = equipmentDto.Description

                };

                await _equipmentRepository.AddEquipmentAsync(equipment);

                reply.Dados = await _equipmentRepository.GetAllEquipmentsAsync();
                reply.Mensagem = "Equipment successfully created";

                return reply;
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException($"Error creating equipment: {ex.Message}");
            }
        }



        public async Task<ResponseModel<EquipmentModel>> UpdateEquipment(EditEquipmentDto equipmentDto)
        {
            ResponseModel<EquipmentModel> reply = new();
            try
            {
                var equipment = await _equipmentRepository.GetEquipmentByIdAsync(equipmentDto.Id);

                if (equipment == null)
                {
                    throw new NotFoundException("Equipment not found by ID");
                }

                

                await _equipmentRepository.UpdateEquipmentAsync(equipment);

                reply.Dados = await _equipmentRepository.GetEquipmentByIdAsync(equipment.Id);
                reply.Mensagem = "Equipment updated successfully";

                return reply;


            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException($"Error retrieving equipments: {ex.Message}");
            }

        }

        public async Task<ResponseModel<EquipmentModel>> GetEquipment(int equipmentId)
        {
            ResponseModel<EquipmentModel> reply = new();

            try
            {
                var equipment = await _equipmentRepository.GetEquipmentByIdAsync(equipmentId);

                reply.Dados = equipment;
                reply.Mensagem = "Equipment successfully retrieved";
                return reply;

            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException($"Error retrieving equipment: {ex.Message}");
            }

        }
        public async Task<ResponseModel<List<EquipmentModel>>> ListAllEquipmentsInArea(int areaId)
        {
            ResponseModel<List<EquipmentModel>> reply = new();
            try
            {
                reply.Dados = await _equipmentRepository.GetEquipmentsInAreaAsync(areaId);
                reply.Mensagem = "Equipments successfully retrieved";
                return reply;
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException($"Error retrieving equipments: {ex.Message}");
            }
        }

        public async Task<ResponseModel<List<EquipmentModel>>> ListAllEquipmentsInBranch(int branchId)
        {
            ResponseModel<List<EquipmentModel>> reply = new();
            try
            {

                reply.Dados = await _equipmentRepository.GetAllEquipmentsInBranchAsync(branchId);
                reply.Mensagem = "Equipments successfully retrieved";
                return reply;
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException($"Error retrieving equipments: {ex.Message}");
            }
        }

        public async Task<ResponseModel<List<EquipmentModel>>> ListAllEquipmentsInCompany(int companyId)
        {
            ResponseModel<List<EquipmentModel>> reply = new();
            try
            {
               
                reply.Dados = await _equipmentRepository.GetAllEquipmentsInCompanyAsync(companyId);
                reply.Mensagem = "Equipments successfully retrieved";
                return reply;
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException($"Error retrieving equipments: {ex.Message}");
            }
        }

        public async Task<ResponseModel<EquipmentModel>> DetailsAboutEquipment(int id)
        {
            ResponseModel<EquipmentModel> reply = new();
            try
            {
                reply.Dados = await _equipmentRepository.GetAllDetailsAboutEquipmentAsync(id);
                reply.Mensagem = "Equipments datails successfully retrieved";
                return reply;
            }

            catch (DbUpdateException ex)
            {
                throw new DbUpdateException($"Error retrieving equipments details: {ex.Message}");
            }



        }

        public async Task<ResponseModel<bool>> DeleteEquipment(int equipmentId)
        {
            ResponseModel<bool> reply = new();

            try
            {
                var equipment = await _equipmentRepository.GetEquipmentByIdAsync(equipmentId);
                if (equipment == null)
                {
                    throw new NotFoundException("Equipment not found");
                }

                await _equipmentRepository.DeleteEquipmentAsync(equipment);

                reply.Dados = true;
                reply.Mensagem = "Equipment deleted successfully";
                return reply;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting equipment: {ex.Message}");
            }
        }

        public async Task<ResponseModel<double>> ListAllEquipmentsExpenseinArea(int areaId)
        {
            ResponseModel<double> reply = new();
            try
            {
                reply.Dados = await _equipmentRepository.AllEquipmentExpenseInArea(areaId);
                reply.Mensagem = "Equipments expense successfully retrieved";
                return reply;
            }

            catch (DbUpdateException ex)
            {
                throw new DbUpdateException($"Error retrieving expense: {ex.Message}");
            }

        }

        public async Task<ResponseModel<double>> ListAllEquipmentsExpenseinBranch(int branchId)
        {
            ResponseModel<double> reply = new();
            try
            {
                reply.Dados = await _equipmentRepository.AllEquipmentExpenseInBranch(branchId);
                reply.Mensagem = "Equipments expense successfully retrieved";
                return reply;
            }

            catch (DbUpdateException ex)
            {
                throw new DbUpdateException($"Error retrieving expense: {ex.Message}");
            }

        }

        public async Task<ResponseModel<List<EquipmentModel>>> AllEquipments()
        {
            ResponseModel<List<EquipmentModel>> reply = new();

            try
            {
                reply.Dados = await _equipmentRepository.GetAllEquipmentsAsync();
                reply.Mensagem = "Equipments successfully retrieved";
                return reply;
            }

            catch (DbUpdateException ex)
            {
                throw new DbUpdateException($"Error retrieving equipmets: {ex.Message}");
            }

        }
    }
}
