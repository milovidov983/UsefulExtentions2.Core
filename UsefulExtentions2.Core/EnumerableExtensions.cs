using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UsefulExtentions2.Core {
	public static class EnumerableExtensions {
		public static bool IsNullOrEmpty<T>(this IEnumerable<T> seq) {
			if (seq != null) {
				return !seq.Any();
			}
			return true;
		}
	}
}
