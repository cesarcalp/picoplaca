using PicoPlaca.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PicoPlaca.Domain.Rules
{
    public interface IPicoPlacaRule
    {
        bool Validate(RuleParam param);
    }
}
