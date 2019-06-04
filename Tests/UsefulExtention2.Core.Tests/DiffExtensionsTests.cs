using System;
using System.Collections.Generic;
using System.Text;
using UsefulExtentions2.Core;
using System.Linq;
using Xunit;

namespace UsefulExtention2.Core.Tests {
	public class DiffExtensionsTests {
		[Fact]
		public void DiffTo_SetTwoDifferentCollections_ReturnAllElements() {
			var left = new[] { "a", "b", "c" };
			var right = new[] { "a1", "b1", "c1" };

			var result = left.DiffTo(right, StringComparer.InvariantCulture, StringComparer.InvariantCulture);


			Assert.Equal(6, result.Count());
			Assert.Equal(3, result.Select(x => x.Left).Intersect(left).Count());
			Assert.Equal(3, result.Select(x => x.Right).Intersect(right).Count());
		}

		[Fact]
		public void DiffTo_SetTwoCollectionsWithOneSameElements_ReturnOnlyUniqElements() {
			var left = new[] { "a", "b", "c" };
			var right = new[] { "a", "b1", "c1" };

			var result = left.DiffTo(right, StringComparer.InvariantCulture, StringComparer.InvariantCulture);

			var leftExpected = new[] { "b", "c" };
			var rightExpected = new[] { "b1", "c1" };

			Assert.Equal(4, result.Count());
			Assert.Equal(2, result.Select(x => x.Left).Intersect(leftExpected).Count());
			Assert.Equal(2, result.Select(x => x.Right).Intersect(rightExpected).Count());
		}
	}
}
