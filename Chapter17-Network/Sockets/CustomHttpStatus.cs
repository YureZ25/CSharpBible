namespace Sockets
{
    internal enum CustomHttpStatus : int
    {
        Ok = 200,

        UnknownError = 0,
        HostNotFound = -1,
        CantConnect = -2,
        Unavailable = -3,
        UnknownCode = -4,
    }
}
