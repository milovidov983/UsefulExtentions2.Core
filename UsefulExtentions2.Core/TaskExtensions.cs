using System;
using System.Threading.Tasks;

namespace UsefulExtentions2.Core {
	public static class TaskExtensions {
		public static async Task<TOut> Then<TIn, TOut>(this Task<TIn> input, Func<TIn, TOut> process) {
			await Task.WhenAll(input);
			return process(input.Result);
		}
	}
}