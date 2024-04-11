namespace MDM_API.Utilities
{
    public static class AuthQueries
    {
        public const string LOGIN = "MATCH (tk:TaiKhoan) WHERE tk.Email = $username and tk.MatKhau = $password return tk.Email, tk.MatKhau";

        public const string GET_USERS = "MATCH (tk:TaiKhoan) return tk.Email, tk.MatKhau";
    }
}
