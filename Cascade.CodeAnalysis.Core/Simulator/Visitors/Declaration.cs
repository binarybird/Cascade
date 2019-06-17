using Cascade.CodeAnalysis.Common.Extensions;
using Cascade.CodeAnalysis.Common.Simulation;
using Cascade.CodeAnalysis.Graph;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Cascade.CodeAnalysis.Core.Simulator.Visitors
{
    partial class Simulator
    {
        public override Evaluation VisitAccessorDeclaration(AccessorDeclarationSyntax node)
        {
            foreach (AttributeListSyntax list in node.AttributeLists)
            {
                list?.Accept<Evaluation>(this);
            }

            node.ExpressionBody?.Accept<Evaluation>(this);
            node.Body?.Accept<Evaluation>(this);

            return base.VisitAccessorDeclaration(node);
        }

        public override Evaluation VisitAnonymousObjectMemberDeclarator(AnonymousObjectMemberDeclaratorSyntax node)
        {
            node.Expression?.Accept<Evaluation>(this);
            node.NameEquals?.Accept<Evaluation>(this);

            return base.VisitAnonymousObjectMemberDeclarator(node);
        }

        public override Evaluation VisitCatchDeclaration(CatchDeclarationSyntax node)
        {
            node.Type?.Accept<Evaluation>(this);
            
            return base.VisitCatchDeclaration(node);
        }

        public override Evaluation VisitClassDeclaration(ClassDeclarationSyntax node)
        {
            foreach (AttributeListSyntax attributeList in node.AttributeLists)
            {
                attributeList.Accept<Evaluation>(this);
            }

            node.BaseList?.Accept<Evaluation>(this);
            foreach (MemberDeclarationSyntax member in node.Members)
            {
                member.Accept<Evaluation>(this);
            }

            node.TypeParameterList?.Accept<Evaluation>(this);
            
            return base.VisitClassDeclaration(node);
        }

        public override Evaluation VisitDelegateDeclaration(DelegateDeclarationSyntax node)
        {
            foreach (AttributeListSyntax attributeList in node.AttributeLists)
            {
                attributeList.Accept<Evaluation>(this);
            }

            foreach (TypeParameterConstraintClauseSyntax clause in node.ConstraintClauses)
            {
                clause.Accept<Evaluation>(this);
            }

            node.ParameterList?.Accept<Evaluation>(this);
            node.ReturnType?.Accept<Evaluation>(this);
            node.TypeParameterList?.Accept<Evaluation>(this);

            return base.VisitDelegateDeclaration(node);
        }

        public override Evaluation VisitEnumDeclaration(EnumDeclarationSyntax node)
        {
            foreach (AttributeListSyntax attributeList in node.AttributeLists)
            {
                attributeList.Accept<Evaluation>(this);
            }

            node.BaseList?.Accept<Evaluation>(this);
            foreach (EnumMemberDeclarationSyntax member in node.Members)
            {
                member.Accept<Evaluation>(this);
            }
            
            return base.VisitEnumDeclaration(node);
        }

        public override Evaluation VisitEnumMemberDeclaration(EnumMemberDeclarationSyntax node)
        {
            foreach (AttributeListSyntax attributeList in node.AttributeLists)
            {
                attributeList.Accept<Evaluation>(this);
            }

            node.EqualsValue?.Accept<Evaluation>(this);
            
            return base.VisitEnumMemberDeclaration(node);
        }

        public override Evaluation VisitEventDeclaration(EventDeclarationSyntax node)
        {
            foreach (AttributeListSyntax attributeList in node.AttributeLists)
            {
                attributeList.Accept<Evaluation>(this);
            }

            node.AccessorList?.Accept<Evaluation>(this);
            node.ExplicitInterfaceSpecifier?.Accept<Evaluation>(this);
            node.Type?.Accept<Evaluation>(this);

            return base.VisitEventDeclaration(node);
        }

        public override Evaluation VisitEventFieldDeclaration(EventFieldDeclarationSyntax node)
        {
            foreach (AttributeListSyntax attributeList in node.AttributeLists)
            {
                attributeList.Accept<Evaluation>(this);
            }

            node.Declaration?.Accept<Evaluation>(this);
            
            return base.VisitEventFieldDeclaration(node);
        }

        public override Evaluation VisitFieldDeclaration(FieldDeclarationSyntax node)
        {
            foreach (AttributeListSyntax attributeList in node.AttributeLists)
            {
                attributeList.Accept<Evaluation>(this);
            }

            node.Declaration?.Accept<Evaluation>(this);
            
            return base.VisitFieldDeclaration(node);
        }


        public override Evaluation VisitInterfaceDeclaration(InterfaceDeclarationSyntax node)
        {
            foreach (AttributeListSyntax attributeList in node.AttributeLists)
            {
                attributeList.Accept<Evaluation>(this);
            }

            node.BaseList?.Accept<Evaluation>(this);

            foreach (TypeParameterConstraintClauseSyntax clause in node.ConstraintClauses)
            {
                clause.Accept<Evaluation>(this);
            }
            
            foreach (MemberDeclarationSyntax member in node.Members)
            {
                member.Accept<Evaluation>(this);
            }

            node.TypeParameterList?.Accept<Evaluation>(this);

            return base.VisitInterfaceDeclaration(node);
        }

        public override Evaluation VisitNamespaceDeclaration(NamespaceDeclarationSyntax node)
        {
            foreach (ExternAliasDirectiveSyntax nodeExtern in node.Externs)
            {
                nodeExtern.Accept<Evaluation>(this);
            }

            node.Name?.Accept<Evaluation>(this);
            foreach (UsingDirectiveSyntax nodeUsing in node.Usings)
            {
                nodeUsing.Accept<Evaluation>(this);
            }

            foreach (MemberDeclarationSyntax member in node.Members)
            {
                member.Accept<Evaluation>(this);
            }

            return base.VisitNamespaceDeclaration(node);
        }

        public override Evaluation VisitOperatorDeclaration(OperatorDeclarationSyntax node)
        {
            foreach (AttributeListSyntax attributeList in node.AttributeLists)
            {
                attributeList.Accept<Evaluation>(this);
            }

            node.ParameterList?.Accept<Evaluation>(this);
            node.ReturnType?.Accept<Evaluation>(this);
            node.Body?.Accept<Evaluation>(this);
            node.ExpressionBody?.Accept<Evaluation>(this);
           
            return base.VisitOperatorDeclaration(node);
        }

        public override Evaluation VisitConversionOperatorDeclaration(ConversionOperatorDeclarationSyntax node)
        {
            foreach (AttributeListSyntax attributeList in node.AttributeLists)
            {
                attributeList.Accept<Evaluation>(this);
            }

            node.Body?.Accept<Evaluation>(this);
            node.ExpressionBody?.Accept<Evaluation>(this);
            node.ParameterList?.Accept<Evaluation>(this);
            node.Type?.Accept<Evaluation>(this);

            return base.VisitConversionOperatorDeclaration(node);
        }

        public override Evaluation VisitConstructorDeclaration(ConstructorDeclarationSyntax node)
        {
            node.ParameterList?.Accept<Evaluation>(this);
            node.Initializer?.Accept<Evaluation>(this);
            node.ExpressionBody?.Accept<Evaluation>(this);
            
            foreach (AttributeListSyntax attributeList in node.AttributeLists)
            {
                attributeList.Accept<Evaluation>(this);
            }

            node.Body?.Accept<Evaluation>(this);
            
            return base.VisitConstructorDeclaration(node);
        }

        public override Evaluation VisitDestructorDeclaration(DestructorDeclarationSyntax node)
        {
            foreach (AttributeListSyntax attributeList in node.AttributeLists)
            {
                attributeList.Accept<Evaluation>(this);
            }

            node.ExpressionBody?.Accept<Evaluation>(this);
            node.Body?.Accept<Evaluation>(this);
            node.ParameterList?.Accept<Evaluation>(this);

            return base.VisitDestructorDeclaration(node);
        }


        public override Evaluation VisitIndexerDeclaration(IndexerDeclarationSyntax node)
        {
            foreach (AttributeListSyntax attributeList in node.AttributeLists)
            {
                attributeList.Accept<Evaluation>(this);
            }

            node.AccessorList?.Accept<Evaluation>(this);
            node.ExplicitInterfaceSpecifier?.Accept<Evaluation>(this);
            node.ExpressionBody?.Accept<Evaluation>(this);
            node.ParameterList?.Accept<Evaluation>(this);
            node.Type?.Accept<Evaluation>(this);

            return base.VisitIndexerDeclaration(node);
        }

        public override Evaluation VisitMethodDeclaration(MethodDeclarationSyntax node)
        {
            Node<Evaluation> owningInstanceNode = _callStack.Peek().ContainingHeap.OwningInstance.Node;
            GraphBuilder<Evaluation>.From(owningInstanceNode).Kind(Edge<Evaluation>.Kind.Declares).To(_callStack.Peek().Node);

            //todo assert node == frame
            foreach (AttributeListSyntax attributeList in node.AttributeLists)
            {
                attributeList.Accept<Evaluation>(this);
            }

            foreach (TypeParameterConstraintClauseSyntax clause in node.ConstraintClauses)
            {
                clause.Accept<Evaluation>(this);
            }

            node.ExplicitInterfaceSpecifier?.Accept<Evaluation>(this);

            //TODO - look for instances corresponding to args
            //TODO - push/pop identity from args here

            Evaluation evaluation = node.ParameterList?.Accept<Evaluation>(this);
            Evaluation evaluation1 = node.ReturnType?.Accept<Evaluation>(this);
            Evaluation evaluation2 = node.TypeParameterList?.Accept<Evaluation>(this);
            Evaluation evaluation3 = node.Body?.Accept<Evaluation>(this);
            Evaluation evaluation4 = node.ExpressionBody?.Accept<Evaluation>(this);

            return base.VisitMethodDeclaration(node);
        }

        public override Evaluation VisitPropertyDeclaration(PropertyDeclarationSyntax node)
        {
            foreach (AttributeListSyntax attributeList in node.AttributeLists)
            {
                attributeList.Accept<Evaluation>(this);
            }

            node.ExplicitInterfaceSpecifier?.Accept<Evaluation>(this);
            node.AccessorList?.Accept<Evaluation>(this);
            node.Type?.Accept<Evaluation>(this);
            node.Initializer?.Accept<Evaluation>(this);
            node.ExpressionBody?.Accept<Evaluation>(this);
            
            return base.VisitPropertyDeclaration(node);
        }

        public override Evaluation VisitStructDeclaration(StructDeclarationSyntax node)
        {
            foreach (AttributeListSyntax attributeList in node.AttributeLists)
            {
                attributeList.Accept<Evaluation>(this);
            }

            node.BaseList?.Accept<Evaluation>(this);
            foreach (TypeParameterConstraintClauseSyntax clause in node.ConstraintClauses)
            {
                clause.Accept<Evaluation>(this);
            }

            node.TypeParameterList?.Accept<Evaluation>(this);
            foreach (MemberDeclarationSyntax member in node.Members)
            {
                member.Accept<Evaluation>(this);
            }
            
            return base.VisitStructDeclaration(node);
        }

        public override Evaluation VisitVariableDeclaration(VariableDeclarationSyntax node)
        {
            node.Type?.Accept<Evaluation>(this);
            foreach (VariableDeclaratorSyntax variable in node.Variables)
            {
                variable.Accept<Evaluation>(this);
            }
            
            return base.VisitVariableDeclaration(node);
        }

        public override Evaluation VisitVariableDeclarator(VariableDeclaratorSyntax node)
        {            
            node.ArgumentList?.Accept<Evaluation>(this);
            
            Evaluation eval = node.Initializer?.Accept<Evaluation>(this);

            Frame frame = _callStack.Peek();
            if (eval is Instance inst)
            {
                ISymbol s = node.GetReference().GetDeclaringSymbol(_comp);
                inst.Identities.Push(new Identity(s, Node<Evaluation>.Kind.LocalVariable, frame, node.Identifier.ValueText));
            }
            else
            {
                ISymbol declaringSymbol = ((VariableDeclarationSyntax) node.Parent).Type.GetReference().GetDeclaringSymbol(_comp);
              //  eval = frame.CreateInstance(node.GetReference(), _comp, node.Identifier.ValueText);
            }

            return eval;
        }
    }
}
