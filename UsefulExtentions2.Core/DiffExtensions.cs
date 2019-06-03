using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UsefulExtentions2.Core {
	public static class DiffExtensions {
		/// <summary>
		/// The function returns unique items found in two collections. 
		/// Collections must be cleared of duplicate items.
		/// </summary>
		public static IEnumerable<DiffItem<T>> DiffTo<T>(
		  this IEnumerable<T> leftSeq,
		  IEnumerable<T> rightSeq,
		  IComparer<T> comparer,
		  IEqualityComparer<T> equalityComparer) {

			var leftArray = leftSeq.OrderBy((v => v), comparer).ToArray();
			var rightArray = rightSeq.OrderBy((v => v), comparer).ToArray();
			var leftIndex = 0;
			var rightIndex = 0;

			while (leftIndex < leftArray.Length && rightIndex < rightArray.Length) {
				var left = leftArray[leftIndex];
				var right = rightArray[rightIndex];

				var cmp = comparer.Compare(left, right);
				if (cmp == 0) {
					if (!equalityComparer.Equals(left, right)) {
						yield return DiffItem<T>.Modified(left, right);
					}
					leftIndex++;
					rightIndex++;
				} else if (cmp < 0) {
					yield return DiffItem<T>.OnlyInLeft(left);
					leftIndex++;
				} else {
					yield return DiffItem<T>.OnlyInRight(right);
					rightIndex++;
				}
			}

			for (var i = leftIndex; i < leftArray.Length; i++) {
				yield return DiffItem<T>.OnlyInLeft(leftArray[i]);
			}
			for (var i = rightIndex; i < rightArray.Length; i++) {
				yield return DiffItem<T>.OnlyInRight(rightArray[i]);
			}
		}
	}
}
