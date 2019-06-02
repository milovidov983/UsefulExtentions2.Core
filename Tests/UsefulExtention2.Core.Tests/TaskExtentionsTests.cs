using System;
using System.Threading.Tasks;
using Xunit;
using UsefulExtentions2.Core;

namespace UsefulExtention2.Core.Tests {
	public class TaskExtentionsTests {
		[Fact]
		public async Task ThenFunction_PutAndCallLambda_ReturnReuslt() {
			Func<Task<int>> funcUnderTest = async () => {
				await Task.Delay(1);
				return 1;
			};

			var result = await funcUnderTest().Then(x => x + 1);

			Assert.Equal(2, result);

		}
	}
}
