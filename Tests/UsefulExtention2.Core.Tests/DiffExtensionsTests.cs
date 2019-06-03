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
		}
	}
}
