﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoopingAudioConverter {
	public class LWAVExporter : IAudioExporter {
		public void WriteFile(LWAV lwav, string output_dir, string original_filename_no_ext) {
			string output_filename = Path.Combine(output_dir, original_filename_no_ext + ".wav");
			File.WriteAllBytes(output_filename, lwav.Export());
		}

		public Task WriteFileAsync(LWAV lwav, string output_dir, string original_filename_no_ext) {
			Task t = new Task(() => WriteFile(lwav, output_dir, original_filename_no_ext));
			t.Start();
			return t;
		}

		public string GetExporterName() {
			return "LWAVExporter";
		}
	}
}