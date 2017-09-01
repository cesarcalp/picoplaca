using PicoPlaca.Domain;
using System;
using PicoPlaca.Models;
using PicoPlaca.Transversal;
using PicoPlaca.Models.Constants;
using PicoPlaca.Domain.Rules;

namespace PicoPlaca.ManagementService
{
    public class PredictorManagementService : IPredictorManagementService
    {
        private IPicoPlacaRule _picoPlacaRule;
        public PredictorManagementService(IPicoPlacaRule picoPlacaRule)
        {
            _picoPlacaRule = picoPlacaRule;
        }
        public VerifierResponse ValidatePicoPlaca(PicoPlacaParam picoPlacaParam)
        {
            var date = UtilConverter.ConvertToDate(picoPlacaParam.Date);
            var time = UtilConverter.ConvertToTime(picoPlacaParam.Time);
            var allowed = _picoPlacaRule.Validate(new RuleParam
            {
                Date = date,
                Time = time,
                PlateNumber = picoPlacaParam.PlateNumber
            });
            return new VerifierResponse
            {
                Code = Codes.Success,
                Message = string.Empty,
                AllowedToRoad = allowed
            };
        }
    }
}
