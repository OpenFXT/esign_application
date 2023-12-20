from pyhanko import stamp 
from pyhanko.pdf_utils import images 
from pyhanko.pdf_utils.incremental_writer import IncrementalPdfFileWriter
from pyhanko.sign import fields, signers, timestamps 

with open("source_var.txt", "r") as file:
    source_var = file.read()
    list_var = source_var.split("#")
    #source_var = tệp_khóa#tệp_xác_thực#mật_khẩu_khóa#file_pdf_gốc#vị_trí_ký#tên_trường_ký#trang_ký#lý_do_ký#ảnh_chữ_ký

signer = signers.SimpleSigner.load(
    key_file=list_var[0], cert_file=list_var[1], key_passphrase=list_var[2].encode()
)

timestamper = timestamps.HTTPTimeStamper(url="http://timestamp.digicert.com")

with open(list_var[3], "rb") as doc:
    writer = IncrementalPdfFileWriter(doc)
    place = list_var[4].split(",")
    fields.append_signature_field(
        writer,
        sig_field_spec=fields.SigFieldSpec(
            list_var[5], on_page=int(list_var[6]), box=(int(place[0]), int(place[1]),int(place[2]),int(place[3]))
        ),
    )
    signature_metadata1 = signers.PdfSignatureMetadata(
        field_name=list_var[5], reason=list_var[7]
    )
    pdf_signer1 = signers.PdfSigner(
        signature_meta=signature_metadata1,
        signer=signer,
        timestamper=timestamper,
        stamp_style=stamp.StaticStampStyle(
            border_width=0,
            background=images.PdfImage(list_var[8]),
        ),
    )
    with open("DocumentRes.pdf", "wb") as output:
        pdf_signer1.sign_pdf(writer, output=output)

with open("res.txt", "w") as file:
    file.write("1")