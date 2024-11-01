using CompanyAPI.Dto.EmployeeDTOS;
using CompanyAPI.Dto.EquipmentDTOS;
using CompanyAPI.Services.Exceptions;
using CompanyAPI.ViewModel;
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
                bool AreaExist = await _equipmentRepository.CheckAreaExistByIdAsync(equipmentDto.AreaId);
                if (!AreaExist)
                {
                    throw new NotFoundException("Area not found");
                }

                var equipment = new EquipmentModel()
                {
                    AreaId = equipmentDto.AreaId,
                    Name = equipmentDto.NameEquipment,
                    Price = equipmentDto.Price
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

                bool areaExist = await _equipmentRepository.CheckAreaExistByIdAsync(equipmentDto.AreaId);

                if (!areaExist)
                {
                    throw new NotFoundException("Area not found by ID");
                }


                double priceDiference = equipment.Price - equipmentDto.Price;

                equipment.Name = equipmentDto.NameEquipment;
                equipment.Price = equipmentDto.Price;
                equipment.AreaId = equipmentDto.AreaId;

                equipment.AreaLinked.Expense += priceDiference;
                equipment.AreaLinked.LinkedBranch.Expense += priceDiference;

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

            try {
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

        public async Task<ResponseModel<List<EquipmentModel>>> ListAllEquipmentsInCompany(int companyId)
        {
            ResponseModel<List<EquipmentModel>> reply = new();
            try
            {
                reply.Dados = await _equipmentRepository.GetAllEquipmentsInCompany(companyId);
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
    }
}
