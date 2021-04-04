import 'package:file_selector/file_selector.dart';
import 'package:flutter/material.dart';
import 'package:image_gallery/mvvm/base_view.dart';
import 'package:image_gallery/pages/image_gallery_page/image_view_model.dart';

class ImageView extends StatelessWidget {
  final XFile file;

  ImageView({required this.file});

  @override
  Widget build(BuildContext context) {
    return BaseView<ImageViewModel>(
      onModelReady: (model) async {
        model.file = file;
      },
      builder: (context, model, child) => GestureDetector(
          onTap: () {
            model.goToDetailPage(model.image);
          },
          child: Image.memory(model.thumbnail!),
    );
  }
}
