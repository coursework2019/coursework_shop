﻿using Model.ViewModels.ModeratorViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using WebCustomerApp.Models;

namespace BAL.Interfaces
{
    public interface IModeratorManager
    {
       // ModeratorViewModel Get(int id);
        IEnumerable<ModeratorViewModel> GetModerators();
        ModeratorViewModel GetById(int id);
        void Insert(ModeratorViewModel item);
        ApplicationUser GetUserByEmail(string email);
        void Update(ModeratorViewModel item);
        void Delete(int id);
        ModeratorViewModel GetThisModerator(string userId);
        int GetModeratorsCount(string searchValue);
        IEnumerable<ModeratorViewModel> GetModerators(int page, int countOnPage, string searchValue);



    }
}
