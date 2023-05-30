# Installer Installation

Follow the steps below to install Minesweeper as a desktop application using the installer:

1. Download the latest `.appxbundle` and `.cer` files from the [release section](https://github.com/ManuelKlaer/windows-forms-minesweeper/releases/latest).
2. Begin the installation process by double-clicking the `.cer` file to install the certificate.
3. Click on "Install Certificate" to proceed.
4. In the Certificate Import Wizard, select "Local Machine" and click "Next".
5. If prompted with a User Account Control prompt, click "Yes" to authorize the installation.
6. Choose "Place all certificates in the following store" and click "Browse".
7. Select "Trusted Root Certification Authorities" and click "OK".
8. Click "Next" and then "Finish" to complete the certificate import.
9. A confirmation message will appear, indicating that the import was successful. Click "OK".
10. You can now proceed to install the `.appxbundle` file and launch the Minesweeper application.
11. Enjoy playing Minesweeper!

*Note: The reason for installing the certificate is that the package is not signed by a trusted publisher. By installing the certificate, you are essentially telling your computer that you trust the publisher of the Minesweeper game package. If you have any concerns about installing the certificate or the package, please contact the developers for further assistance.*

---
[Back =>](https://github.com/ManuelKlaer/windows-forms-minesweeper/blob/main/docs/download_choices.md)
