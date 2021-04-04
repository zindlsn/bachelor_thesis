import 'dart:io';

import 'package:flutter/material.dart';
import 'package:image_gallery/models/gallery_image.dart';
import 'package:image_gallery/mvvm/base_view.dart';
import 'package:image_gallery/pages/image_detail_page/image_detail_page_view_model.dart';

class ImageDetailPage extends StatelessWidget {
  GalleryImage image;

  ImageDetailPage({required this.image});

  @override
  Widget build(BuildContext context) {
    return BaseView<ImageDetailPageViewModel>(
      onModelReady: (model) async {},
      builder: (context, model, child) => Scaffold(
        backgroundColor: Theme.of(context).backgroundColor,
        body: SafeArea(
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            mainAxisAlignment: MainAxisAlignment.start,
            children: [
              Expanded(
                child: GestureDetector(
                  onTap: () {
                    model.goBack();
                  },
                  child: Center(
                    child: Image.file(
                      File(image.path),
                      height: 400,
                    ),
                  ),
                ),
              ),
              Text('Details:'),
              Column(
                children: [
                  Container(child: Text(image.title)),
                ],
              )
            ],
          ),
        ),
      ),
    );
  }
}
//mike büttner, heio müller
