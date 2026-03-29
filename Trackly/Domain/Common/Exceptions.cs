namespace Trackly.Domain.Common
{
    // 🔹 404 - Topilmadi
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message) { }
    }

    // 🔹 400 - Noto‘g‘ri request
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message) { }
    }

    // 🔹 401 - Login qilmagan / token yo‘q
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException(string message) : base(message) { }
    }

    // 🔹 403 - Ruxsat yo‘q
    public class ForbiddenException : Exception
    {
        public ForbiddenException(string message) : base(message) { }
    }
}

