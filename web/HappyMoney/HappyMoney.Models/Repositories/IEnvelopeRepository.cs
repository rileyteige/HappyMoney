using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyMoney.Models.Repositories
{
	public interface IEnvelopeRepository
	{
		Envelope GetEnvelope(Guid guid);
		bool UpdateEnvelopes(IEnumerable<Envelope> envelopes);
	}
}
