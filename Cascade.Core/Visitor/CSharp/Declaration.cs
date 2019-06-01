using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Cascade.Core.Visitor.CSharp
{
    public partial class CSharpVisitor
    {
        public override void VisitAccessorDeclaration(AccessorDeclarationSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            foreach (AttributeListSyntax list in node.AttributeLists)
            {
                list?.Accept(this);
            }

            node.ExpressionBody?.Accept(this);
            node.Body?.Accept(this);

            base.VisitAccessorDeclaration(node);
            
            PostVisit(node);

        }

        public override void VisitAnonymousObjectMemberDeclarator(AnonymousObjectMemberDeclaratorSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Expression?.Accept(this);
            node.NameEquals?.Accept(this);

            base.VisitAnonymousObjectMemberDeclarator(node);
            
            PostVisit(node);
        }

        public override void VisitCatchDeclaration(CatchDeclarationSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Type?.Accept(this);
            
            base.VisitCatchDeclaration(node);
            
            PostVisit(node);
        }

        public override void VisitClassDeclaration(ClassDeclarationSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            foreach (AttributeListSyntax attributeList in node.AttributeLists)
            {
                attributeList.Accept(this);
            }

            node.BaseList?.Accept(this);
            foreach (MemberDeclarationSyntax member in node.Members)
            {
                member.Accept(this);
            }

            node.TypeParameterList?.Accept(this);
            
            base.VisitClassDeclaration(node);
            
            PostVisit(node);
        }

        public override void VisitDelegateDeclaration(DelegateDeclarationSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            foreach (AttributeListSyntax attributeList in node.AttributeLists)
            {
                attributeList.Accept(this);
            }

            foreach (TypeParameterConstraintClauseSyntax clause in node.ConstraintClauses)
            {
                clause.Accept(this);
            }

            node.ParameterList?.Accept(this);
            node.ReturnType?.Accept(this);
            node.TypeParameterList?.Accept(this);

            base.VisitDelegateDeclaration(node);
            
            PostVisit(node);
        }

        public override void VisitEnumDeclaration(EnumDeclarationSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            foreach (AttributeListSyntax attributeList in node.AttributeLists)
            {
                attributeList.Accept(this);
            }

            node.BaseList?.Accept(this);
            foreach (EnumMemberDeclarationSyntax member in node.Members)
            {
                member.Accept(this);
            }
            
            base.VisitEnumDeclaration(node);
            
            PostVisit(node);
        }

        public override void VisitEnumMemberDeclaration(EnumMemberDeclarationSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            foreach (AttributeListSyntax attributeList in node.AttributeLists)
            {
                attributeList.Accept(this);
            }

            node.EqualsValue?.Accept(this);
            
            base.VisitEnumMemberDeclaration(node);
            
            PostVisit(node);
        }

        public override void VisitEventDeclaration(EventDeclarationSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            foreach (AttributeListSyntax attributeList in node.AttributeLists)
            {
                attributeList.Accept(this);
            }

            node.AccessorList?.Accept(this);
            node.ExplicitInterfaceSpecifier?.Accept(this);
            node.Type?.Accept(this);

            base.VisitEventDeclaration(node);
            
            PostVisit(node);
        }

        public override void VisitEventFieldDeclaration(EventFieldDeclarationSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            foreach (AttributeListSyntax attributeList in node.AttributeLists)
            {
                attributeList.Accept(this);
            }

            node.Declaration?.Accept(this);
            
            base.VisitEventFieldDeclaration(node);
            
            PostVisit(node);
        }

        public override void VisitFieldDeclaration(FieldDeclarationSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            foreach (AttributeListSyntax attributeList in node.AttributeLists)
            {
                attributeList.Accept(this);
            }

            node.Declaration?.Accept(this);
            
            base.VisitFieldDeclaration(node);
            
            PostVisit(node);
        }


        public override void VisitInterfaceDeclaration(InterfaceDeclarationSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            foreach (AttributeListSyntax attributeList in node.AttributeLists)
            {
                attributeList.Accept(this);
            }

            node.BaseList?.Accept(this);

            foreach (TypeParameterConstraintClauseSyntax clause in node.ConstraintClauses)
            {
                clause.Accept(this);
            }
            
            foreach (MemberDeclarationSyntax member in node.Members)
            {
                member.Accept(this);
            }

            node.TypeParameterList?.Accept(this);

            base.VisitInterfaceDeclaration(node);
            
            PostVisit(node);
        }

        public override void VisitNamespaceDeclaration(NamespaceDeclarationSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            foreach (ExternAliasDirectiveSyntax nodeExtern in node.Externs)
            {
                nodeExtern.Accept(this);
            }

            node.Name?.Accept(this);
            foreach (UsingDirectiveSyntax nodeUsing in node.Usings)
            {
                nodeUsing.Accept(this);
            }

            foreach (MemberDeclarationSyntax member in node.Members)
            {
                member.Accept(this);
            }

            base.VisitNamespaceDeclaration(node);
            
            PostVisit(node);
        }

        public override void VisitOperatorDeclaration(OperatorDeclarationSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            foreach (AttributeListSyntax attributeList in node.AttributeLists)
            {
                attributeList.Accept(this);
            }

            node.ParameterList?.Accept(this);
            node.ReturnType?.Accept(this);
            node.Body?.Accept(this);
            node.ExpressionBody?.Accept(this);
           
            base.VisitOperatorDeclaration(node);
            
            PostVisit(node);

        }

        public override void VisitConversionOperatorDeclaration(ConversionOperatorDeclarationSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            foreach (AttributeListSyntax attributeList in node.AttributeLists)
            {
                attributeList.Accept(this);
            }

            node.Body?.Accept(this);
            node.ExpressionBody?.Accept(this);
            node.ParameterList?.Accept(this);
            node.Type?.Accept(this);

            base.VisitConversionOperatorDeclaration(node);
            
            PostVisit(node);
        }

        public override void VisitConstructorDeclaration(ConstructorDeclarationSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            foreach (AttributeListSyntax attributeList in node.AttributeLists)
            {
                attributeList.Accept(this);
            }

            node.Body?.Accept(this);
            node.ExpressionBody?.Accept(this);
            node.Initializer?.Accept(this);
            node.ParameterList?.Accept(this);

            base.VisitConstructorDeclaration(node);
            
            PostVisit(node);
        }

        public override void VisitDestructorDeclaration(DestructorDeclarationSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            foreach (AttributeListSyntax attributeList in node.AttributeLists)
            {
                attributeList.Accept(this);
            }

            node.ExpressionBody?.Accept(this);
            node.Body?.Accept(this);
            node.ParameterList?.Accept(this);

            base.VisitDestructorDeclaration(node);
            
            PostVisit(node);
        }


        public override void VisitIndexerDeclaration(IndexerDeclarationSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            foreach (AttributeListSyntax attributeList in node.AttributeLists)
            {
                attributeList.Accept(this);
            }

            node.AccessorList?.Accept(this);
            node.ExplicitInterfaceSpecifier?.Accept(this);
            node.ExpressionBody?.Accept(this);
            node.ParameterList?.Accept(this);
            node.Type?.Accept(this);

            base.VisitIndexerDeclaration(node);
            
            PostVisit(node);
        }

        public override void VisitMethodDeclaration(MethodDeclarationSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            foreach (AttributeListSyntax attributeList in node.AttributeLists)
            {
                attributeList.Accept(this);
            }

            foreach (TypeParameterConstraintClauseSyntax clause in node.ConstraintClauses)
            {
                clause.Accept(this);
            }

            node.ExplicitInterfaceSpecifier?.Accept(this);
            node.ParameterList?.Accept(this);
            node.ReturnType?.Accept(this);
            node.TypeParameterList?.Accept(this);
            node.Body?.Accept(this);
            node.ExpressionBody?.Accept(this);

            base.VisitMethodDeclaration(node);
            
            PostVisit(node);

        }

        public override void VisitPropertyDeclaration(PropertyDeclarationSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            foreach (AttributeListSyntax attributeList in node.AttributeLists)
            {
                attributeList.Accept(this);
            }

            node.ExplicitInterfaceSpecifier?.Accept(this);
            node.AccessorList?.Accept(this);
            node.Type?.Accept(this);
            node.Initializer?.Accept(this);
            node.ExpressionBody?.Accept(this);
            
            base.VisitPropertyDeclaration(node);
            
            PostVisit(node);
        }

        public override void VisitStructDeclaration(StructDeclarationSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            foreach (AttributeListSyntax attributeList in node.AttributeLists)
            {
                attributeList.Accept(this);
            }

            node.BaseList?.Accept(this);
            foreach (TypeParameterConstraintClauseSyntax clause in node.ConstraintClauses)
            {
                clause.Accept(this);
            }

            node.TypeParameterList?.Accept(this);
            foreach (MemberDeclarationSyntax member in node.Members)
            {
                member.Accept(this);
            }
            
            base.VisitStructDeclaration(node);
            
            PostVisit(node);
        }

        public override void VisitVariableDeclaration(VariableDeclarationSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Type?.Accept(this);
            foreach (VariableDeclaratorSyntax variable in node.Variables)
            {
                variable.Accept(this);
            }
            
            base.VisitVariableDeclaration(node);
            
            PostVisit(node);
        }

        public override void VisitVariableDeclarator(VariableDeclaratorSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.ArgumentList?.Accept(this);
            node.Initializer?.Accept(this);

            base.VisitVariableDeclarator(node);
            
            PostVisit(node);
        }
    }
}
