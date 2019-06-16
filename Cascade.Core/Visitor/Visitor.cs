using Microsoft.CodeAnalysis;

namespace Cascade.CodeAnalysis.Core.Visitor.CSharp
{
    public interface Visitor
    {
        bool PreVisit(SyntaxNode node);
        void PostVisit(SyntaxNode node);
        void Visit(SyntaxNode node);
    }
}