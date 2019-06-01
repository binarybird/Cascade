using Microsoft.CodeAnalysis;

namespace Cascade.Core.Visitor
{
    public interface Visitor
    {
        bool PreVisit(SyntaxNode node);
        void PostVisit(SyntaxNode node);
        void Visit(SyntaxNode node);
    }
}