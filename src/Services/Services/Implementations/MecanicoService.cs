using Models.Dao;
using Models.Dto;
using Models.Factory;
using Services.Interfaces;
using System.Collections.Generic;
using UnitOfWork.Interfaces;

namespace Services.Implementations
{
    public class MecanicoService : IMecanicoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MecanicoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<MecanicoDto> GetAll()
        {
            IEnumerable<Mecanico> list;

            using (var context = _unitOfWork.Create())
            {
                list = context.Repositories.MecanicoRepository.GetAll();
            }

            return list.ToMecanicoDto();
        }

        public void Create(MecanicoDto form)
        {
            var model = form.ToMecanicoDao();

            using (var context = _unitOfWork.Create())
            {
                context.Repositories.MecanicoRepository.Create(model);
            }
        }

        
        public void Update(MecanicoDto form)
        {
            var model = form.ToMecanicoDao();

            using (var context = _unitOfWork.Create())
            {
                context.Repositories.MecanicoRepository.Update(model);
            }
        }

        
        public void Remove(MecanicoDto form)
        {
            var model = form.ToMecanicoDao();

            using (var context = _unitOfWork.Create())
            {
                context.Repositories.MecanicoRepository.Remove(model);
            }
        }

    }
}
