using System;
using System.Collections.Generic;
using System.Text;
using WheelsForHire.Models;

namespace WheelsForHire.Interfaces
{
    public interface IDamageDepositModelFactory
    {
        DamageDepositModel GenerateModel(int damageDepositId);
    }
}
