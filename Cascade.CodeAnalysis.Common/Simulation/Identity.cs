﻿using System;
using Cascade.CodeAnalysis.Common.Extensions;
using Cascade.CodeAnalysis.Graph;
using Microsoft.CodeAnalysis;

namespace Cascade.CodeAnalysis.Common.Simulation
{
    public class Identity : Evaluation
    {
        private ISymbol _symbol;

        public ISymbol Symbol
        {
            get { return _symbol; }
            set
            {
                _symbol = value;
                Update();
            }
        }

        public string Identifier { get; private set; }
        public string ManualIdentifier { get; set; }
        public bool IsLocal { get; private set; }
        public bool IsProperty { get; private set; }
        public bool IsField { get; private set; }
        public bool IsParam { get; private set; }
        public bool IsFunctional { get; private set; }
        public bool IsDisposed { get; set; }
        public Frame Frame { get; set;  }
        public ITypeSymbol Type { get; private set; }
        public Node<Evaluation> Node { get; }

        public Identity(SyntaxReference reference, Compilation compilation, NodeKind kind, Frame frame = null, string manualIdentifier = null) : this(reference.GetSymbol(compilation), kind, frame, manualIdentifier)
        {
        }
            
        public Identity(ISymbol symbol, NodeKind kind, Frame frame = null, string manualIdentifier = null)
        {
            Frame = frame;
            _symbol = symbol;
            ManualIdentifier = manualIdentifier;
            Update();
        }

        public bool EqualsIdentifier(string ident)
        {
            if (ident == null)
            {
                return false;
            }

            return ident.Equals(Identifier) || ident.Equals(ManualIdentifier);
        }


        private void Update()
        {
            if (_symbol is ILocalSymbol local)
            {
                IsLocal = true;
                IsProperty = false;
                IsField = false;
                IsParam = false;
                IsFunctional = false;
                Type = local.Type;
                Identifier = local.Name;
            }
            else if (_symbol is IFieldSymbol field)
            {
                IsLocal = false;
                IsProperty = false;
                IsField = true;
                IsParam = false;
                IsFunctional = false;
                Type = field.Type;
                Identifier = field.Name;
            }
            else if (_symbol is IPropertySymbol prop)
            {
                IsLocal = false;
                IsProperty = true;
                IsField = false;
                IsParam = false;
                IsFunctional = false;
                Type = prop.Type;
                Identifier = prop.Name;
            }
            else if (_symbol is IParameterSymbol param)
            {
                IsLocal = true;
                IsProperty = false;
                IsField = false;
                IsParam = true;
                IsFunctional = false;
                Type = param.Type;
                Identifier = param.Name;
            }
            else if (_symbol is ITypeSymbol type)
            {
                IsLocal = true;
                IsProperty = false;
                IsField = false;
                IsParam = false;
                IsFunctional = false;
                Type = type;
                Identifier = type.Name;
            }
            else if (Symbol is IMethodSymbol meth)
            {
                IsLocal = false;
                IsProperty = false;
                IsField = false;
                IsParam = false;
                IsFunctional = true;
                Type = meth.ReceiverType;
                Identifier = meth.Name;
            }
            else
            {
                throw new Exception("Invalid symbol type for identity");
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is Identity ident)
            {
                bool ret = EqualsIdentifier(ident.Identifier) || EqualsIdentifier(ident.ManualIdentifier);
                return ret && Frame.Equals(ident.Frame);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return $"Identity[Type=\"{Type.ToDisplayString(RoslynExtensions.TYPE_FMT)}\", Identifier=\"{Identifier}\", ManualIdentifier=\"{ManualIdentifier}\"]";
        }
    }
}