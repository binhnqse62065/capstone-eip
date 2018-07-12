﻿using AutoMapper.QueryableExtensions;
using HmsService.Models;
using HmsService.Models.Entities;
using HmsService.ViewModels;
using SkyWeb.DatVM.Mvc;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using HmsService.Sdk;
using System;

namespace HmsService.Sdk
{
    public partial class InteractionApi
    {
        public int? GetVotingIdBySessionId(int sessionId)
        {
            return this.BaseService.GetVotingIdBySessionId(sessionId);
        }

        public int GetQaIdBySessionId(int sessionId)
        {
            return (int)this.BaseService.GetQaBySessionId(sessionId);
        }
    }
}
