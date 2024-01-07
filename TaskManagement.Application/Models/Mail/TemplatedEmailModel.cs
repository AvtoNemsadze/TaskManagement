namespace TaskManagement.Application.Models.Mail
{
    public class TemplatedEmailModel
    {
        public string Body { get; set; } = string.Empty;
        public string Receiver { get; set; } = string.Empty;
        public List<string>? TemplateItems { get; set; }  
        public bool IsBodyHtml { get; set; }
        public List<FileAttachments>? Attachments { get; set; }
        public string Subject { get; set; } = string.Empty;
        public string DisplayEmail { get; set; } = string.Empty;
    }
    public class FileAttachments
    {
        public byte[]? AttachmentData { get; set; } 
        public string AttachmentName { get; set; } = string.Empty;
    }
}
