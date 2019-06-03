using System;
using System.Collections.Generic;
using System.Text;

namespace UsefulExtentions2.Core {
	public class DiffItem<T> {
		public readonly T Left;
		public readonly T Right;
		public readonly DiffKind Kind;

		public DiffItem(T value, DiffKind kind) {
			Kind = kind;
			if (kind == DiffKind.OnlyInLeft) {
				Left = value;
			} else if (kind == DiffKind.OnlyInRight)  {
				Right = value;
			}
		}

		public DiffItem(T left, T right) {
			Kind = DiffKind.Modified;
			Left = left;
			Right = right;
		}
	}
}
