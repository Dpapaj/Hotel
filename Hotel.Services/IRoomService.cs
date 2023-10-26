using Hotel.Utilities;
using Hotel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Services
{
    public interface IRoomService
    {
        PageResult<RoomViewModel> GettAll(int pageNumber, int pageSize);
        RoomViewModel GetRoomId(int Roomid);
        void UpdateRoom(RoomViewModel Room);
        void InsertRoom(RoomViewModel Room);
        void DeleteRoom(int id);
        
    }
}
