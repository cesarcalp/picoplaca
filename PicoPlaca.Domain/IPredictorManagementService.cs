using PicoPlaca.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PicoPlaca.Domain
{
    public interface IPredictorManagementService
    {
        VerifierResponse ValidatePicoPlaca(PicoPlacaParam picoPlacaParam);
    }
}
