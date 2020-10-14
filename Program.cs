using MEI.SPDocuments;
using MEI.SPDocuments.Document;
using MEI.SPDocuments.Type;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharepointUploaderTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var spDocs = new SP_Documents("meidomain1\\cthompson"))
            {
                //var doc = DocumentFactory.Instance.CreateProgramDetailsSubmissionForm(23456, File.ReadAllBytes(@"C:\Users\cthompson\Downloads\PDSF__23456.pdf"), "pdf", CompanyCode.Abbott);
                //spDocs.IsValidateFields = false;
                //var ur = spDocs.Upload(doc);
                var seg = new SearchExpressionGroup(SPDocumentTypeCode.PDSF, SearchBooleanLogicCode.And);
                seg.AddExpression((int)PDSFFieldName.PdsfId, CamlComparisonCode.Equal, 23456);
                var sr = spDocs.Search(SPDocumentTypeCode.PDSF, CompanyCode.LabDevelopment, seg);
            }
        }
    }
}
