using System;
using Cascade.Common.Extensions;
using Microsoft.CodeAnalysis;

namespace Cascade.Common.Simulation
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

        public String Identifier { get; set; }
        public bool IsLocal { get; private set; }
        public bool IsProperty { get; private set; }
        public bool IsField { get; private set; }
        public bool IsParam { get; private set; }
        public Frame Frame { get; private set; }
        public ITypeSymbol Type { get; private set; }

        public Identity(Frame frame, SyntaxReference reference, Compilation compilation, String identifier = null)
        {
            Frame = frame;
            _symbol = reference.GetDeclaringSymbol(compilation);
            if (_symbol == null)
            {
                _symbol = reference.GetSymbolInfo(compilation).Symbol;
            }
            Identifier = identifier;
            Update();
        }
            
        public Identity(Frame frame, ISymbol symbol = null, String identifier = null)
        {
            Frame = frame;
            _symbol = symbol;
            Identifier = identifier;
            Update();
        }

        private void Update()
        {
            if (_symbol is ILocalSymbol local)
            {
                IsLocal = true;
                IsProperty = false;
                IsField = false;
                IsParam = false;
                Type = local.Type;
            }
            else if (_symbol is IFieldSymbol field)
            {
                IsLocal = false;
                IsProperty = false;
                IsField = true;
                IsParam = false;
                Type = field.Type;
            }
            else if (_symbol is IPropertySymbol prop)
            {
                IsLocal = false;
                IsProperty = true;
                IsField = false;
                IsParam = false;
                Type = prop.Type;
            }
            else if (_symbol is IParameterSymbol param)
            {
                IsLocal = true;
                IsProperty = false;
                IsField = false;
                IsParam = true;
                Type = param.Type;
            }
            else if (_symbol is ITypeSymbol type)
            {
                IsLocal = true;
                IsProperty = false;
                IsField = false;
                IsParam = false;
                Type = type;
            }
//            else if (Symbol is IMethodSymbol meth)
//            {
//
//            }
            else
            {
                throw new Exception("Invalid symbol type for identity");
            }
        }

        public override string ToString()
        {
            return $"Identity[Type=\"{Type.ToDisplayString(RoslynExtensions.TYPE_FMT)}\", Identifier=\"{Identifier}\"]";
        }
    }
}