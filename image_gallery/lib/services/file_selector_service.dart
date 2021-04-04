import 'package:file_selector/file_selector.dart';
import 'package:file_selector_platform_interface/file_selector_platform_interface.dart';

///
/// Class for FileSelector.
///
class FileSelectorService {
  final jpgsTypeGroup = XTypeGroup(
    label: 'JPEGs',
    extensions: ['jpg', 'jpeg'],
  );
  final pngTypeGroup = XTypeGroup(
    label: 'PNGs',
    extensions: ['png'],
  );

  ///
  /// Opens the fileselector and returns the files.
  ///
  Future<List<XFile>> openFileSelectorAsync() async {
    return await FileSelectorPlatform.instance
        .openFiles(acceptedTypeGroups: [jpgsTypeGroup, pngTypeGroup]);
  }
}
