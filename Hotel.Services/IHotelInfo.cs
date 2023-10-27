using Hotel.Utilities;
using Hotel.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Services
{
    public interface IHotelInfo
    {
        PageResult<HotelInfoViewModel> GetAll(int pageNumber,int pageSize);
        HotelInfoViewModel GetHotelById(int HotelId);
        void UpdateHotelInfo(HotelInfoViewModel hotelInfo);
        void InsertHotelInfo(HotelInfoViewModel hotelInfo);
        void DeleteHotelInfo(int id);
    }
}
