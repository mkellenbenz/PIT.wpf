﻿using PIT.Business.Entities;

namespace PIT.WPF.Core.Contracts
{
    public interface IPITWindowManager
    {
        void ApplyScreenBoundaries(double screenWidht, double screenheight);
        WindowLocation GetCenteredWindowLocation(double desiredWidth, double desiredHeight);
    }
}
