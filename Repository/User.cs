using MIS_Admin.Core;
using MySql.Data.MySqlClient;
using System.Data;

namespace MIS_Admin.Repository
{
    internal class User : Base
    {
        public DataTable FindUser(object username)
        {
            string stmt = $@"
            SELECT   
            a.UserID AS UserID,
            a.ParticularID AS ParticularID,
            a.UserName AS UserName,
            a.FullName AS FullName,
            a.`Password` AS `Password`,		
            a.MD5Password AS MD5Password,
            a.UserType AS UserType,
            IFNULL(b.isActive, 0) AS isActive,
            IFNULL(b.isAppVersion, 0) AS isAppVersion,
            a.MobileID AS MobileID,
            c.TerminalID AS MobileTerminalID,
            c.TerminalName AS MobileTerminalName
            FROM tbluser a
            LEFT JOIN tblparticular AS b ON a.ParticularID = b.ParticularID
            LEFT JOIN tblterminal AS c ON a.MobileID = c.TID
            WHERE a.UserName = @username";

            return SelectNoCache(stmt, new MySqlParameter("@username", username));
        }
    }
}
