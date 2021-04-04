import 'package:flutter/material.dart';
import 'package:image_gallery/globals.dart';
import 'package:image_gallery/models/gallery_image.dart';
import 'package:image_gallery/pages/image_detail_page/image_detail_page.dart';
import 'package:image_gallery/pages/image_gallery_page/image_gallery_page.dart';

/// Copied from the project
/// https://github.com/FilledStacks/flutter-tutorials/tree/master/025-navigation-service/02-final
class RouteGenerator {
  static Route<dynamic> generateRoute(RouteSettings settings) {
    switch (settings.name) {
      case kDetailImagePage:
        var galleryImage = settings.arguments as GalleryImage;
        return MaterialPageRoute(
          builder: (context) => ImageDetailPage(image: galleryImage),
        );
      case kImageGalleryPage:
        return MaterialPageRoute(
          builder: (context) => ImageGalleryPage(),
        );
      default:
        return MaterialPageRoute(
          builder: (context) => Scaffold(
            body: Center(
              child: Text('No page found for ${settings.name}'),
            ),
          ),
        );
    }
  }
}
