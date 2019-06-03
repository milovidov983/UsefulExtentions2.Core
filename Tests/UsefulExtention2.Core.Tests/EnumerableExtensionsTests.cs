using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using UsefulExtentions2.Core;

namespace UsefulExtention2.Core.Tests {
	public class EnumerableExtensionsTests {
		[Fact]
		public void IsNullOrEmpty_SetEmptyCollection_ReturnTrue() {
			var emptyArray = new int[] { };

			var result = emptyArray.IsNullOrEmpty();

			Assert.True(result);
		}

		[Fact]
		public void IsNullOrEmpty_SetFilledCollection_ReturnFalse() {
			var emptyArray = new int[] { 1 };

			var result = emptyArray.IsNullOrEmpty();

			Assert.False(result);
		}

		[Fact]
		public void IsNullOrEmpty_SetNullCollection_ReturnTrue() {
			int[] emptyArray = null;

			var result = emptyArray.IsNullOrEmpty();

			Assert.True(result);
		}
	}
}
