using Cascade.Common.Simulation;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Cascade.Core.Simulator.Visitors
{
    partial class Simulator
    {
        public override Evaluation VisitAccessorList(AccessorListSyntax node)
        {
            EvaluationList list = new EvaluationList();
            foreach (AccessorDeclarationSyntax accessor in node.Accessors)
            {
                list.Add(accessor.Accept<Evaluation>(this));
            }

            return list;
        }

        public override Evaluation VisitArgumentList(ArgumentListSyntax node)
        {
            EvaluationList list = new EvaluationList();
            foreach (ArgumentSyntax argument in node.Arguments)
            {
                list.Add(argument.Accept<Evaluation>(this));
            }

            return list;
        }

        public override Evaluation VisitAttributeArgumentList(AttributeArgumentListSyntax node)
        {
            EvaluationList list = new EvaluationList();
            foreach (AttributeArgumentSyntax argument in node.Arguments)
            {
                list.Add(argument.Accept<Evaluation>(this));
            }

            return list;
        }

        public override Evaluation VisitAttributeList(AttributeListSyntax node)
        {
            EvaluationList list = new EvaluationList();
            foreach (AttributeSyntax attribute in node.Attributes)
            {
                list.Add(attribute.Accept<Evaluation>(this));
            }

            node.Target?.Accept<Evaluation>(this);

            return list;
        }

        public override Evaluation VisitBaseList(BaseListSyntax node)
        {
            EvaluationList list = new EvaluationList();
            foreach (BaseTypeSyntax type in node.Types)
            {
                list.Add(type.Accept<Evaluation>(this));
            }

            return list;
        }

        public override Evaluation VisitBracketedArgumentList(BracketedArgumentListSyntax node)
        {
            EvaluationList list = new EvaluationList();
            foreach (ArgumentSyntax argument in node.Arguments)
            {
                list.Add(argument.Accept<Evaluation>(this));
            }

            return list;
        }

        public override Evaluation VisitBracketedParameterList(BracketedParameterListSyntax node)
        {
            EvaluationList list = new EvaluationList();
            foreach (ParameterSyntax parameter in node.Parameters)
            {
                list.Add(parameter.Accept<Evaluation>(this));
            }

            return list;
        }

        public override Evaluation VisitParameterList(ParameterListSyntax node)
        {
            EvaluationList list = new EvaluationList();
            foreach (ParameterSyntax parameter in node.Parameters)
            {
                list.Add(parameter.Accept<Evaluation>(this));
            }

            return list;
        }

        public override Evaluation VisitTypeArgumentList(TypeArgumentListSyntax node)
        {
            EvaluationList list = new EvaluationList();
            foreach (TypeSyntax argument in node.Arguments)
            {
                list.Add(argument.Accept<Evaluation>(this));
            }

            return list;
        }

        public override Evaluation VisitTypeParameterList(TypeParameterListSyntax node)
        {
            EvaluationList list = new EvaluationList();
            foreach (TypeParameterSyntax parameter in node.Parameters)
            {
                list.Add(parameter.Accept<Evaluation>(this));
            }

            return list;
        }
    }
}
