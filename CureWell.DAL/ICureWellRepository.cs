﻿using CureWell.Entity;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CureWell.DAL
{
    public interface ICureWellRepository
    {
        bool AddDoctor(Doctor dObj);
        bool DeleteDoctor(int doctorId);
        List<Doctor> GetAllDoctors();
        Doctor GetDoctorById(int doctorId);
        List<Specialization> GetAllSpecializations();
        List<Surgery> GetAllSurgeries();
        List<Surgery> GetAllSurgeryTypeForToday();
        Surgery GetSurgeryById(int surgeryId);
        List<DoctorSpecialization> GetDoctorsBySpecialization(string specializationCode);
        bool UpdateDoctorDetails(Doctor dObj);
        bool UpdateSurgery(Surgery sObj);
        DoctorDetails GetDoctorDetails(int doctorId);
        bool AddSpecialization(Specialization sObj);
        bool AddSurgery(Surgery sObj);
        bool AddDoctorSpecialization(DoctorSpecialization dsObj);
        User Login(User uObj);
    }
}
