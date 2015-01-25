using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyMoney.Models.Repositories
{
	public class EnvelopeRepository : IEnvelopeRepository
	{
		private readonly HappyMoneyEntities _context = new HappyMoneyEntities();

		public Envelope GetEnvelope(Guid guid)
		{
			if (guid == null || guid == Guid.Empty)
			{
				throw new ArgumentNullException("guid");
			}

			return _context.Envelopes.SingleOrDefault(env => env.Guid == guid);
		}

		public bool UpdateEnvelopes(IEnumerable<Envelope> envelopes)
		{
			if (envelopes == null)
			{
				throw new ArgumentNullException("envelopes");
			}

			return _context.SaveChanges() >= 0;
		}
	}
}
