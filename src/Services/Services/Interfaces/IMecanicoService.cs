using System.Collections;
using System.Collections.Generic;
using Models.Dto;

namespace Services.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IMecanicoService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<MecanicoDto> GetAll();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="form"></param>
        void Create(MecanicoDto form);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="form"></param>
        void Update(MecanicoDto form);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="form"></param>
        void Remove(MecanicoDto form);
    }
}
