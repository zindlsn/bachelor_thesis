import 'package:image_gallery/models/gallery_image.dart';
import 'package:image_gallery/mvvm/base_model.dart';

import 'file:///D:/repos/Bachelor_Arbeit/Code/code/image_gallery/lib/services/navigation_service.dart';

import '../../main.dart';

class ImageDetailPageViewModel extends BaseModel {
  List<GalleryImage> images = [];

  void goBack() {
    locator<NavigationService>().goBack();
  }
}
