using BlendoBot.Core.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BlendoBot.Core.Tests.Demo {
	public class DemoCommandDependenciesTests {
		[Fact]
		public void TestNoCommands() {
			var commands = Array.Empty<Type>();
			var dependencyTree = new CommandDependencyTree(commands);
			Assert.Empty(dependencyTree.NoDependencyNodes);
			Assert.Empty(dependencyTree.Nodes);
		}

		[Fact]
		public void TestSomeInvalidCommandTypes() {
			var commands = new Type[] {
				typeof(DemoCommandDependenciesTests),
				typeof(DemoCommandRoot)
			};
			Assert.Throws<ArgumentException>(() => new CommandDependencyTree(commands));
		}

		[Fact]
		public void TestAllInvalidCommandTypes() {
			var commands = new Type[] {
				typeof(DemoCommandDependenciesTests)
			};
			Assert.Throws<ArgumentException>(() => new CommandDependencyTree(commands));
		}

		[Fact]
		public void TestNoDependencies() {
			var commands = new Type[] {
				typeof(DemoCommandRoot)
			};
			var dependencyTree = new CommandDependencyTree(commands);
			Assert.Single(dependencyTree.NoDependencyNodes);
			var root = dependencyTree.NoDependencyNodes.Single().Value;
			Assert.Equal(typeof(DemoCommandRoot), root.CommandType);
			Assert.Empty(root.DependedBy);
			Assert.Empty(root.DependsOn);
			Assert.Equal("blendobot.core.demo.democommandroot", root.Guid);
			Assert.Single(dependencyTree.Nodes);
			Assert.Same(root, dependencyTree.Nodes.Single().Value);
			Assert.Equal("blendobot.core.demo.democommandroot", dependencyTree.Nodes.Single().Key);
		}

		[Fact]
		public void TestBasicDependency() {
			var commands = new Type[] {
				typeof(DemoCommandTierOne)
			};
			var dependencyTree = new CommandDependencyTree(commands);
			Assert.Single(dependencyTree.NoDependencyNodes);
			Assert.Equal(2, dependencyTree.Nodes.Count);
		}

		private static void TestSingleTierTwoDependency<TierTwo>(Type[] commands) where TierTwo : BaseCommand {
			var dependencyTree = new CommandDependencyTree(commands);
			Assert.Single(dependencyTree.NoDependencyNodes);
			Assert.Equal(3, dependencyTree.Nodes.Count);
			var root = dependencyTree.NoDependencyNodes.Single().Value;
			Assert.Equal(typeof(TierTwo), root.DependedBy.Single().Value.DependedBy.Single().Value.CommandType);
		}

		[Fact]
		public void TestTierTwoADependency1() {
			var commands = new Type[] {
				typeof(DemoCommandTierTwoA),
				typeof(DemoCommandTierOne),
				typeof(DemoCommandRoot)
			};
			TestSingleTierTwoDependency<DemoCommandTierTwoA>(commands);
		}

		[Fact]
		public void TestTierTwoADependency2() {
			var commands = new Type[] {
				typeof(DemoCommandTierTwoA),
				typeof(DemoCommandRoot)
			};
			TestSingleTierTwoDependency<DemoCommandTierTwoA>(commands);
		}

		[Fact]
		public void TestTierTwoADependency3() {
			var commands = new Type[] {
				typeof(DemoCommandTierTwoA)
			};
			TestSingleTierTwoDependency<DemoCommandTierTwoA>(commands);
		}

		[Fact]
		public void TestTierTwoBDependency1() {
			var commands = new Type[] {
				typeof(DemoCommandTierTwoB),
				typeof(DemoCommandTierOne),
				typeof(DemoCommandRoot)
			};
			TestSingleTierTwoDependency<DemoCommandTierTwoB>(commands);
		}

		[Fact]
		public void TestTierTwoBDependency2() {
			var commands = new Type[] {
				typeof(DemoCommandTierTwoB),
				typeof(DemoCommandRoot)
			};
			TestSingleTierTwoDependency<DemoCommandTierTwoB>(commands);
		}

		[Fact]
		public void TestTierTwoBDependency3() {
			var commands = new Type[] {
				typeof(DemoCommandTierTwoB)
			};
			TestSingleTierTwoDependency<DemoCommandTierTwoB>(commands);
		}

		[Fact]
		public void TestTierTwoBothDependency() {
			var commands = new Type[] {
				typeof(DemoCommandTierTwoA),
				typeof(DemoCommandTierTwoB)
			};
			var dependencyTree = new CommandDependencyTree(commands);
			Assert.Single(dependencyTree.NoDependencyNodes);
			Assert.Equal(4, dependencyTree.Nodes.Count);
			var root = dependencyTree.NoDependencyNodes.Single().Value;
			Assert.Equal(2, root.DependedBy.Single().Value.DependedBy.Count);
		}

		[Fact]
		public void TestTierThreeDependency() {
			var commands = new Type[] {
				typeof(DemoCommandTierThree)
			};
			var dependencyTree = new CommandDependencyTree(commands);
			Assert.Single(dependencyTree.NoDependencyNodes);
			Assert.Equal(5, dependencyTree.Nodes.Count);
			var root = dependencyTree.NoDependencyNodes.Single().Value;
			Assert.Equal(2, root.DependedBy.Single().Value.DependedBy.Count);
			Assert.Same(root.DependedBy.Single().Value.DependedBy.First().Value.DependedBy.Single().Value, root.DependedBy.Single().Value.DependedBy.Last().Value.DependedBy.Single().Value);
		}

		private static void TestBadDependencyLoop(Type[] commands) {
			Assert.Throws<InvalidOperationException>(() => new CommandDependencyTree(commands));
		}

		[Fact]
		public void TestBadDependencyLoopOne() {
			var commands = new Type[] {
				typeof(DemoCommandBadDependencyOne)
			};
			TestBadDependencyLoop(commands);
		}

		[Fact]
		public void TestBadDependencyLoopTwo() {
			var commands = new Type[] {
				typeof(DemoCommandBadDependencyTwo)
			};
			TestBadDependencyLoop(commands);
		}

		[Fact]
		public void TestBadDependencyLoopBoth() {
			var commands = new Type[] {
				typeof(DemoCommandBadDependencyOne),
				typeof(DemoCommandBadDependencyTwo)
			};
			TestBadDependencyLoop(commands);
		}
	}
}
