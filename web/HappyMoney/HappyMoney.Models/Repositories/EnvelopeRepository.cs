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

		public bool DeleteEnvelope(Guid guid)
		{
			if (guid == null || guid == Guid.Empty)
			{
				throw new ArgumentNullException("guid");
			}

			var envelope = _context.Envelopes.SingleOrDefault(env => env.Guid == guid);
			if (envelope == null)
			{
				return false;
			}

			_context.Envelopes.Remove(envelope);
			_context.SaveChanges();

			return true;
		}

		public Guid CreateEnvelope(int budgetId, string name)
		{
			if (budgetId <= 0)
			{
				throw new ArgumentOutOfRangeException("budgetId", "Must be > 0.");
			}
			if (string.IsNullOrEmpty(name))
			{
				throw new ArgumentNullException("name");
			}

			Envelope envelope = new Envelope()
			{
				Name = name,
				Capacity = 0.0,
				Guid = Guid.NewGuid(),
				BudgetId = budgetId
			};

			_context.Envelopes.Add(envelope);
			_context.SaveChanges();

			return envelope.Guid;
		}
	}
}
