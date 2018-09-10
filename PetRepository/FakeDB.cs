﻿using System;
using System.Collections.Generic;
using EASV.PetShop.Entities;

namespace EASV.PetShop.Infrastructure.Data
{
    public class FakeDB
    {
        public static int Id = 1;
        public static readonly List<Pet> Pets = new List<Pet>();

        public static int OwnerId = 1;
        public static readonly List<Owner> Owners = new List<Owner>();
    }
}
