using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Cascade.Core.Extract.Visitors
{
    partial class InfoExtractor
    {
        public override void VisitAccessorDeclaration(AccessorDeclarationSyntax node)
        {
            foreach (AttributeListSyntax list in node.AttributeLists)
            {
                list?.Accept(this);
            }

            node.ExpressionBody?.Accept(this);
            node.Body?.Accept(this);

            base.VisitAccessorDeclaration(node);
        }

        public override void VisitAnonymousObjectMemberDeclarator(AnonymousObjectMemberDeclaratorSyntax node)
        {
            node.Expression?.Accept(this);
            node.NameEquals?.Accept(this);

            base.VisitAnonymousObjectMemberDeclarator(node);
        }

        public override void VisitCatchDeclaration(CatchDeclarationSyntax node)
        {
            Information.Add(InfoExtractor.Info.NAME, node.Identifier.Value);
            
            node.Type?.Accept(this);
            
            base.VisitCatchDeclaration(node);
        }

        public override void VisitClassDeclaration(ClassDeclarationSyntax node)
        {
            Information.Add(InfoExtractor.Info.NAME, node.Identifier.Value);
            
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
        }

        public override void VisitDelegateDeclaration(DelegateDeclarationSyntax node)
        {
            Information.Add(InfoExtractor.Info.NAME, node.Identifier.Value);
            
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
        }

        public override void VisitEnumDeclaration(EnumDeclarationSyntax node)
        {
            Information.Add(InfoExtractor.Info.NAME, node.Identifier.Value);
            
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
        }

        public override void VisitEnumMemberDeclaration(EnumMemberDeclarationSyntax node)
        {
            Information.Add(InfoExtractor.Info.NAME, node.Identifier.Value);
            
            foreach (AttributeListSyntax attributeList in node.AttributeLists)
            {
                attributeList.Accept(this);
            }

            node.EqualsValue?.Accept(this);
            
            base.VisitEnumMemberDeclaration(node);
        }

        public override void VisitEventDeclaration(EventDeclarationSyntax node)
        {
            Information.Add(InfoExtractor.Info.NAME, node.Identifier.Value);
            
            foreach (AttributeListSyntax attributeList in node.AttributeLists)
            {
                attributeList.Accept(this);
            }

            node.AccessorList?.Accept(this);
            node.ExplicitInterfaceSpecifier?.Accept(this);
            node.Type?.Accept(this);

            base.VisitEventDeclaration(node);
        }

        public override void VisitEventFieldDeclaration(EventFieldDeclarationSyntax node)
        {
            foreach (AttributeListSyntax attributeList in node.AttributeLists)
            {
                attributeList.Accept(this);
            }

            node.Declaration?.Accept(this);
            
            base.VisitEventFieldDeclaration(node);
        }

        public override void VisitFieldDeclaration(FieldDeclarationSyntax node)
        {
            foreach (AttributeListSyntax attributeList in node.AttributeLists)
            {
                attributeList.Accept(this);
            }

            node.Declaration?.Accept(this);
            
            base.VisitFieldDeclaration(node);
        }


        public override void VisitInterfaceDeclaration(InterfaceDeclarationSyntax node)
        {
            Information.Add(InfoExtractor.Info.NAME, node.Identifier.Value);
            
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
        }

        public override void VisitNamespaceDeclaration(NamespaceDeclarationSyntax node)
        {
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
        }

        public override void VisitOperatorDeclaration(OperatorDeclarationSyntax node)
        {
            
            foreach (AttributeListSyntax attributeList in node.AttributeLists)
            {
                attributeList.Accept(this);
            }

            node.ParameterList?.Accept(this);
            node.ReturnType?.Accept(this);
            node.Body?.Accept(this);
            node.ExpressionBody?.Accept(this);
           
            base.VisitOperatorDeclaration(node);
        }

        public override void VisitConversionOperatorDeclaration(ConversionOperatorDeclarationSyntax node)
        {
            foreach (AttributeListSyntax attributeList in node.AttributeLists)
            {
                attributeList.Accept(this);
            }

            node.Body?.Accept(this);
            node.ExpressionBody?.Accept(this);
            node.ParameterList?.Accept(this);
            node.Type?.Accept(this);

            base.VisitConversionOperatorDeclaration(node);
        }

        public override void VisitConstructorDeclaration(ConstructorDeclarationSyntax node)
        {
            Information.Add(InfoExtractor.Info.NAME, node.Identifier.Value);
            
            foreach (AttributeListSyntax attributeList in node.AttributeLists)
            {
                attributeList.Accept(this);
            }

            node.Body?.Accept(this);
            node.ExpressionBody?.Accept(this);
            node.Initializer?.Accept(this);
            node.ParameterList?.Accept(this);

            base.VisitConstructorDeclaration(node);
        }

        public override void VisitDestructorDeclaration(DestructorDeclarationSyntax node)
        {
            Information.Add(InfoExtractor.Info.NAME, node.Identifier.Value);
            
            foreach (AttributeListSyntax attributeList in node.AttributeLists)
            {
                attributeList.Accept(this);
            }

            node.ExpressionBody?.Accept(this);
            node.Body?.Accept(this);
            node.ParameterList?.Accept(this);

            base.VisitDestructorDeclaration(node);
        }


        public override void VisitIndexerDeclaration(IndexerDeclarationSyntax node)
        {
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
        }

        public override void VisitMethodDeclaration(MethodDeclarationSyntax node)
        {
            Information.Add(InfoExtractor.Info.NAME, node.Identifier.Value);
            
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
        }

        public override void VisitPropertyDeclaration(PropertyDeclarationSyntax node)
        {
            foreach (AttributeListSyntax attributeList in node.AttributeLists)
            {
                attributeList.Accept(this);
            }
            
            Information.Add(InfoExtractor.Info.NAME, node.Identifier.Value);

            node.ExplicitInterfaceSpecifier?.Accept(this);
            node.AccessorList?.Accept(this);
            node.Type?.Accept(this);
            node.Initializer?.Accept(this);
            node.ExpressionBody?.Accept(this);
            
            base.VisitPropertyDeclaration(node);
        }

        public override void VisitStructDeclaration(StructDeclarationSyntax node)
        {
            Information.Add(InfoExtractor.Info.NAME, node.Identifier.Value);
            
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
        }

        public override void VisitVariableDeclaration(VariableDeclarationSyntax node)
        {
            node.Type?.Accept(this);
            foreach (VariableDeclaratorSyntax variable in node.Variables)
            {
                variable.Accept(this);
            }
            
            base.VisitVariableDeclaration(node);
        }

        public override void VisitVariableDeclarator(VariableDeclaratorSyntax node)
        {   
            Information.Add(InfoExtractor.Info.NAME, node.Identifier.Value);
            
            node.ArgumentList?.Accept(this);
            node.Initializer?.Accept(this);

            base.VisitVariableDeclarator(node);
        }
    }
}
