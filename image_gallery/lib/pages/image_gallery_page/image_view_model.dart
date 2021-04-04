import 'dart:io';
import 'dart:typed_data';

import 'package:file_selector/file_selector.dart';
import 'package:image_gallery/globals.dart';
import 'package:image_gallery/main.dart';
import 'package:image_gallery/models/gallery_image.dart';
import 'package:image_gallery/mvvm/base_model.dart';
import 'package:image_gallery/services/navigation_service.dart';

///
///
///
class ImageViewModel extends BaseModel {
  late XFile file;

  Uint8List? thumbnail;
  Uint8List? image;

  void goToDetailPage(GalleryImage image) {
    locator<NavigationService>().navigateTo(kDetailImagePage, arguments: image);
  }

  Future<void> loadThumbnailsAnsync(XFile file) async {
    setState(ViewState.Busy);
    try {
        GalleryImage image = GalleryImage()
          ..path = file.path
          ..title = file.name;
    } catch (e) {
      String errorMessage = 'Files could not be loaded';
      this.setErrorMessage(errorMessage);
      throw new FileSystemException(errorMessage);
    }
    setState(ViewState.Idle);
  }
}
}
