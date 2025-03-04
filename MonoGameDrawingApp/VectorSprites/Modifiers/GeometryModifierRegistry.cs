﻿using MonoGameDrawingApp.VectorSprites.Modifiers.Appliable;
using MonoGameDrawingApp.VectorSprites.Modifiers.Appliable.Simple;
using System;
using System.Collections.Generic;

namespace MonoGameDrawingApp.VectorSprites.Modifiers
{
    public static class GeometryModifierRegistry
    {
        private static readonly Func<IGeometryModifier>[] s_modifiers = new Func<IGeometryModifier>[]
        {
            () => new MoveModifier(),
            () => new RandomizeModifier(),
            () => new RoundModifier(),
            () => new SimpleMirrorModifier(),
            () => new MirrorModifier(),
            () => new SubdivideModifier(),
            () => new FlipModifier(),
            () => new ScaleModifier(),
            () => new RotateModifier(),
            () => new ExpandModifier(),
            () => new OutlineModifier(),
            () => new CopyModifier(),
        };

        private static readonly Dictionary<string, Func<IGeometryModifier>> s_nameModifierSet = GenerateNameModifierSet();

        public static IEnumerable<string> ModifierNames => s_nameModifierSet.Keys;

        public static IGeometryModifier GenerateFromName(string modifierName)
        {
            return s_nameModifierSet[modifierName]();
        }

        private static Dictionary<string, Func<IGeometryModifier>> GenerateNameModifierSet()
        {
            Dictionary<string, Func<IGeometryModifier>> res = new();

            foreach (Func<IGeometryModifier> modifierFunc in s_modifiers)
            {
                res[modifierFunc().Name] = modifierFunc;
            }

            return res;
        }
    }
}
